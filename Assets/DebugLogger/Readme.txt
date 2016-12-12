Overview
--------

This asset package shows how to remove debug methods in released games and during profiling

This package demonstrates a way to replace the standard Debug.Log and Debug.LogXXXX methods with ones which can be removed in non-development builds and while profiling.

Ever noticed how debug log lines can still take up processing time and generate garbage.

Have you ever concatenated strings and done variable conversions when using logging methods? e.g Debug.Log("Value = " + value.ToString());

Have you noticed this still costs CPU time in released builds and generates garbage, even though nothing happens to the debug method.

Well this package will wrap the Debug.Log and Debug.LogXXXX methods in a way which is completely compiled out when building release builds. You can also remove the messages by turning them off in the editor preferences. This is useful when profiling a development build.

Simply replace any instances of Debug.Log with DebugLogging.Log

Details
-------

Change any instances of Debug.Log, Debug.LogWarning and Debug.LogError with DebugLogging.Log, DebugLoging.LogWarning, DebugLoging.LogError respectively.

When building in Development mode or the Editor the DebugLogging methods remain part of the code base. In Non-development builds they are removed from the compiled assembly. This means they are no longer part of the assembly and therefore never executed.

This helps improve performance by removing unnecessary function calls and prevents generating additional garbage created mostly by string functions.

For example a line such as:

Debug.Log(“Lives = “ + m_lives.ToString()); 

will call method which concatenates the string and converts an integer value to a string. Then the final parameter is passed to the Debug.Log method which then doesn't actually do anything in a released game. Therefore lines like this are using up valuable CPU time and creating temporary objects which the garbage collector will need to free up.

There is currently a method in Debug system that allows a conditional to be used to avoid Debug.Log statements. e.g.

if ( Debug.isDebugBuild ) Debug.Log(“Lives = “ + m_lives.ToString()); 

This avoids the additional call overhead and string manipulation but it still makes a call to isDebugBuild and you must make sure ever instance of  Debug.Log must have a guard around it.

In released build the DebugLoggin.LogXXXX function will automatically be removed.

Profiling
---------

When building 'Development' the Debug.LogXXX methods will remain to assist with debugging. However when profiling these can cause unwanted CPU overhead that doesn't represent what would happen in a released build. 

Therefore to solve this issue there is a way to disable Debug logging in development builds, which is useful for profiling. 

Open the editor preferences Edit->Preferences and select the Debug Preferences option. In here you can toggle debug logging using 'Enable Logging'. Whenever you change this value your scripts will be recompiled to reflect the changes.

Notes
-----

There a few issues with the level of optimization and how the C# compiler and JIT or AOT will behave.

If you build the follow code in non-developement:

void Update()
{
	if (Debug.isDebugBuild == true)
	{
    		DebugLogging.Log("Position : " + gameObject.name + " : " + gameObject.transform.position);
	}
}

and view the compiled assembly, then you may see the following result:

void Update()
{
	if (Debug.isDebugBuild == true)
	{
	}
}

Although the DebugLogging call has been removed the code around it hasn't, even though the 'if' condition doesn't do anything it may still remain. This depends greatly on the type of platform and how the JIT or AOT will handle this and if it will optimize it away.

This is also true if you have something like:

void Update()
{
	string output = "Rotation : " + gameObject.name;
	output += " : " + gameObject.transform.position;
	output += " : " + gameObject.transform.rotation;
	DebugLogging.Log(output);
}

The actual 'output' string variable may still remain in the code and be concatenated together, even though the DebugLogging method will be removed. Again this is very dependent on how the final build is compiled. 

To get around this issue it is recommended to do any complex string building inside a separate function like so:

void Update()
{
    DebugLogging.Log(BuildDebugOutput());
}

string BuildDebugOutput()
{
	string output = "GameObject : " + gameObject.name;
	output += " : " + gameObject.transform.position;
	output += " : " + gameObject.transform.rotation;
	return output;
}

When the DebugLogging.Log is removed so will the call to BuildDebugOutput()

Issues
------

Be aware that the console output will no longer be able to jump to the debug log line when debugging is enabled. This is because it will take you to the Debug.Log line inside the DebugLogging.Log method.

There are plenty of advanced versions for the console window that allow you to select any line from the call-stack. Alternatively you can write your own as there is reference on the internet on how to do this. This is currently beyond the scope of this asset.

