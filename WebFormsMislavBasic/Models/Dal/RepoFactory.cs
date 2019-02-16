using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebFormsMislavBasic.Models.Dal
{
    public class RepoFactory
    {
        private static Repository repository = new Repository();
        private static RepositoryTextFile txtRepository = new RepositoryTextFile();

        public static string repoSwitch { get; set; }

        public static IRepo GetRepo()
        {
            switch (repoSwitch)
            {
                case "text":
                    return txtRepository;
                case "db":
                    return repository;
                default:
                    return repository;
            }
        }
    }
}