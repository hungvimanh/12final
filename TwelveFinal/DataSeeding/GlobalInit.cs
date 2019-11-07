﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TwelveFinal.Repositories.Models;

namespace DataSeeding
{
    public class GlobalInit
    {
        public TFContext tFContext;

        //public AreaInit AreaInit;
        public DistrictInit DistrictInit;
        public EthnicInit EthnicInit;
        public HighSchoolInit HighSchoolInit;
        public MajorsInit MajorsInit;
        //public PriorityTypeInit PriorityTypeInit;
        public ProvinceInit ProvinceInit;
        public SubjectGroupInit SubjectGroupInit;
        public TownInit TownInit;
        public UniversityInit UniversityInit;
        public University_MajorsInit University_MajorsInit;
        public GlobalInit(TFContext tFContext)
        {
            this.tFContext = tFContext;
            //AreaInit = new AreaInit(tFContext);
            DistrictInit = new DistrictInit(tFContext);
            EthnicInit = new EthnicInit(tFContext);
            HighSchoolInit = new HighSchoolInit(tFContext);
            MajorsInit = new MajorsInit(tFContext);
            //PriorityTypeInit = new PriorityTypeInit(tFContext);
            ProvinceInit = new ProvinceInit(tFContext);
            SubjectGroupInit = new SubjectGroupInit(tFContext);
            TownInit = new TownInit(tFContext);
            UniversityInit = new UniversityInit(tFContext);
            University_MajorsInit = new University_MajorsInit(tFContext);
        }

        public void Init()
        {
            Clean();
            //AreaInit.Init();
            DistrictInit.Init();
            EthnicInit.Init();
            
            MajorsInit.Init();
            //PriorityTypeInit.Init();
            ProvinceInit.Init();
            SubjectGroupInit.Init();
            TownInit.Init();
            UniversityInit.Init();
            HighSchoolInit.Init();
            University_MajorsInit.Init();
            tFContext.SaveChanges();
        }

        public void Clean()
        {
            string condition = "IF OBJECT_ID(''?'') NOT IN (ISNULL(OBJECT_ID(''[dbo].[__MigrationLog]''),0),ISNULL(OBJECT_ID(''[dbo].[__SchemaSnapshot]''),0))";
            string command = string.Format(
              @"EXEC sp_MSForEachTable '{0} ALTER TABLE ? NOCHECK CONSTRAINT ALL';
                EXEC sp_MSForEachTable '{0} BEGIN SET QUOTED_IDENTIFIER ON; DELETE FROM ? END';
                EXEC sp_MSForEachTable '{0} ALTER TABLE ? CHECK CONSTRAINT ALL';", condition);
            var result = tFContext.Database.ExecuteSqlCommand(command);
        }
    }
}
