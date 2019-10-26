using ppedv.VollE.Logic;
using ppedv.VollE.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ppedv.VollE.UI.WPF.ViewModels
{
    class TrainerViewModel
    {
        public ObservableCollection<Trainer> TrainerList { get; set; }

        public ICommand SaveCommand { get; set; }
        public ICommand NewCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
        public ICommand DemoCommand { get; set; }
        public ICommand LadenCommand { get; set; }

        public Trainer SelectedTrainer { get; set; }


        Core core = null;

        public TrainerViewModel()
        {
            TrainerList = new ObservableCollection<Trainer>();
            LoadTrainer();
            LadenCommand = new RelayCommand(p => LoadTrainer());
            DeleteCommand = new RelayCommand(o => {
                core.UnitOfWork.GetRepo<Trainer>().Delete(SelectedTrainer);
                core.UnitOfWork.SaveChanges();
                LoadTrainer();
            });
            NewCommand = new RelayCommand(UserWantsToAddTrainer);
            SaveCommand = new RelayCommand(UserWantsToSaveTrainer);
        }

        private void UserWantsToSaveTrainer(object obj)
        {
            try
            {
                Trainer loaded = core.UnitOfWork.GetRepo<Trainer>().GetById(SelectedTrainer.Id);
                if (loaded == null) core.UnitOfWork.GetRepo<Trainer>().Update(SelectedTrainer);
                else
                    core.UnitOfWork.GetRepo<Trainer>().Add(SelectedTrainer);
                core.UnitOfWork.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void UserWantsToAddTrainer(object obj)
        {
            try
            {
                var trainer = new Trainer { Name = "NewTrainer", Geschlecht = Geschlecht.Divers,
                                            Trainerlizenzstufe = Trainerlizenzstufe.A };
                core.UnitOfWork.GetRepo<Trainer>().Add(trainer);
                TrainerList.Add(trainer);
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void LoadTrainer()
        {
            core = new Core();
            TrainerList.Clear();

            foreach (var item in core.UnitOfWork.GetRepo<Trainer>().Query().OrderBy(x => x.Name).ToList())
            {
                TrainerList.Add(item);
            }
        }
    }
}
