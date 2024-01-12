using System;

namespace Lessons.Architecture
{
    public class UserInteractor : Interactor
    {
        public Action OnChangeName;
        public string NameUser { get; private set; }

        private UserRepository userRepository;

        public override void Initialize()
        {
            base.Initialize();
            userRepository = Game.GetRepository<UserRepository>();
        }

        public override void OnStart()
        {
            base.OnStart();

            NameUser = userRepository.NameUser;
        }

        public void SetData(string name)
        {
            NameUser = name;
        }

        public void Save()
        {
            userRepository.SetData(NameUser);
            userRepository.Save();
            OnChangeName?.Invoke();
        }
    }
}
