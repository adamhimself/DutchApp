using DutchApp.Data.Entities;
using Microsoft.AspNetCore.Hosting;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace DutchApp.Data
{
    public class DutchSeeder
    {
        private DutchContext _ctx;
        private IHostingEnvironment _hosting;

        public DutchSeeder(DutchContext ctx, IHostingEnvironment hosting)
        {
            _ctx = ctx;
            _hosting = hosting;
        }

        public void Seed()
        {
            _ctx.Database.EnsureCreated();

            if (!_ctx.Verbs.Any())
            {
                // Need to create sample data.
                var filepath = Path.Combine(_hosting.ContentRootPath, "Data/verbs.json");
                var filepath_auxVerbs = Path.Combine(_hosting.ContentRootPath, "Data/aux_verbs.json");

                var json = File.ReadAllText(filepath);

                var verbs = JsonConvert.DeserializeObject<IEnumerable<Verb>>(json);

                _ctx.Verbs.AddRange(verbs);
                _ctx.SaveChanges();
            }

            if (!_ctx.AuxiliaryVerbs.Any())
            {
                var filepath_auxVerbs = Path.Combine(_hosting.ContentRootPath, "Data/aux_verbs.json");

                var json = File.ReadAllText(filepath_auxVerbs);

                var verbs = JsonConvert.DeserializeObject<IEnumerable<AuxiliaryVerb>>(json);

                _ctx.AuxiliaryVerbs.AddRange(verbs);
                _ctx.SaveChanges();
            }
        }
    }
}
