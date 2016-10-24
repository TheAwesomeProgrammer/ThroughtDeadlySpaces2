using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Enemy.Attacks.Abstract
{
    public interface AttackSet
    {
        Attackable GetAttack();
    }
}
