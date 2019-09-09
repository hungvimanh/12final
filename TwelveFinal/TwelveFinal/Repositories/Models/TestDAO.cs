﻿using System;
using System.Collections.Generic;

namespace TwelveFinal.Repositories.Models
{
    public partial class TestDAO
    {
        public TestDAO()
        {
            Registers = new HashSet<RegisterDAO>();
        }

        public Guid Id { get; set; }
        public long CX { get; set; }
        public bool Maths { get; set; }
        public bool Literature { get; set; }
        public string ForeignLanguage { get; set; }
        public Guid? ScienceId { get; set; }

        public virtual NaturalSciencesDAO Science { get; set; }
        public virtual SocialScienceDAO ScienceNavigation { get; set; }
        public virtual ICollection<RegisterDAO> Registers { get; set; }
    }
}
