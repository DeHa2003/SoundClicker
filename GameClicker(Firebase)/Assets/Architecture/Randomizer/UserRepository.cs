using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Lessons.Architecture
{
    public class UserRepository : Repository
    {
        public string NameUser { get; private set; }

        private const string KEY = "NAME_USER";

        public override void Initialize()
        {
            NameUser = PlayerPrefs.GetString(KEY, null);
        }

        public void SetData(string name)
        {
            NameUser = name;
        }

        public override void Save()
        {
            PlayerPrefs.SetString(KEY, NameUser);
        }
    }
}
