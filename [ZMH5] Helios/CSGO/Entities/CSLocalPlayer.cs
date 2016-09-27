﻿using ZatsHackBase.Core;
using ZatsHackBase.Maths;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _ZMH5__Helios.CSGO.Entities
{
    public class CSLocalPlayer : CSPlayer
    {
        #region VARIABLES
        private static LazyCache<int> memSize = new LazyCache<int>(() => System.Math.Max(LargestDataTable("DT_Local", "DT_LocalPlayerExclusive"), Program.Offsets.m_iCrosshairID));
        #endregion

        #region PROPERTIES
        public LazyCache<int> m_iCrosshairIdx { get; private set; }
        public LazyCache<Vector3> m_aimPunchAngle { get; private set; }
        public LazyCache<Vector3> m_viewPunchAngle { get; private set; }
        public LazyCache<Vector3> m_vecViewOffset { get; private set; }
        public LazyCache<Vector3> m_vecVelocity { get; private set; }
        public override int MemSize { get { return memSize.Value; } }
        #endregion

        #region CONSTRUCTORS
        public CSLocalPlayer() : base() { }
        public CSLocalPlayer(long address) : base(address, memSize.Value) { }

        public CSLocalPlayer(BaseEntity other) : base(other) { }
        #endregion

        #region METHODS
        protected override void SetupFields()
        {
            base.SetupFields();

            m_iCrosshairIdx = new LazyCache<int>(() => ReadAt<int>(Program.Offsets.m_iCrosshairID));
            m_aimPunchAngle = new LazyCache<Vector3>(() => ReadNetVar<Vector3>("DT_LocalPlayerExclusive", "m_Local", "DT_Local", "m_aimPunchAngle"));
            m_viewPunchAngle = new LazyCache<Vector3>(() => ReadNetVar<Vector3>("DT_LocalPlayerExclusive", "m_Local", "DT_Local", "m_viewPunchAngle"));
            m_vecViewOffset = new LazyCache<Vector3>(() => ReadNetVar<Vector3>("DT_LocalPlayerExclusive", "m_vecViewOffset[0]"));
            m_vecVelocity = new LazyCache<Vector3>(() => ReadNetVar<Vector3>("DT_LocalPlayerExclusive", "m_vecVelocity[0]"));
        }

        public bool CanSee(CSPlayer player, int boneIndex = 6)
        {
            return false;
        }
        #endregion
    }
}