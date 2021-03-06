﻿using SolutionUtility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MBaseAccess.Entity
{
    public class MBaseHeaderTransaction
    {
        [MatchParent("MBaseTranCode")]
        public string MBaseTranCode { get; set; }

        [MatchParent("ScenarioNumber")]
        public string ScenarioNumber { get; set; }

        [MatchParent("ActionMode")]
        public string ActionMode { get; set; }

        [MatchParent("TransactionMode")]
        public string TransactionMode { get; set; }

        [MatchParent("NoOfRecToRetrieve")]
        public string NoOfRecToRetrieve { get; set; }

        [MatchParent("InputLength")]
        public int InputLength { get; set; }

        [MatchParent("ResponseLength")]
        public int ResponseLength { get; set; }

        [MatchParent("Description")]
        public string Description { get; set; }
    }
}
