using EnemyStateMachineScripts.State;
using UnityEngine;

namespace EnemyStateMachineScripts
{
    public class EnemyStateFactory
    {
        private EnemyStateMachine _esm;

        public EnemyStateFactory(EnemyStateMachine esm)
        {
            _esm = esm;
        }


        public EnemyBaseState Run()
        {
            return new EnemyRunState(_esm);
        }
        
        public EnemyBaseState Kill()
        {
            return new EnemyKillState(_esm);
        }
        
        public EnemyBaseState Rotate()
        {
            return new EnemyRotateState(_esm);
        }
    }
}