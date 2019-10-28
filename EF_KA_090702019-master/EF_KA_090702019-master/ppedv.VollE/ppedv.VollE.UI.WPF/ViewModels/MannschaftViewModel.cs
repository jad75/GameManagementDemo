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
   public  class MannschaftViewModel
    {
        public ObservableCollection<Spieler> AlleSpielerExclusivManschaftSpielerList { get; set; } = new ObservableCollection<Spieler>();
        public Spieler SelectedAlleSpielerExclusivMannschaftSpieler { get; set; } 
        public ObservableCollection<Spieler>  SpielerList { get; set; } = new ObservableCollection<Spieler>();
        public Spieler SelectedMannschaftSpieler { get; set; }
        public ObservableCollection<Trainer> TrainerList { get; set; }= new ObservableCollection<Trainer>();
        public Trainer SelectedTrainer { get; set; }
        public ObservableCollection<Mannschaft> MannschaftList { get; set; }
        private Mannschaft _SelectedMannschaft = new Mannschaft();
        public Mannschaft SelectedMannschaft 
        { get
            {
                return _SelectedMannschaft;
            }
            set
            {
                _SelectedMannschaft = value;
                if(_SelectedMannschaft!=null)
                {
                    //clear all List
                    SpielerList.Clear();
                    AlleSpielerExclusivManschaftSpielerList.Clear();
                    TrainerList.Clear();
                    //fetch all List
                    foreach (var item in _SelectedMannschaft.Spieler)
                        SpielerList.Add(item);
                                        
                    foreach (var item in core.UnitOfWork.SpielerRepository.GetAll().
                                                        Where(x => !_SelectedMannschaft.Spieler.Contains(x)).ToList())
                        AlleSpielerExclusivManschaftSpielerList.Add(item);
                    foreach(var item in core.UnitOfWork.GetRepo<Trainer>().GetAll().ToList())
                    {
                        TrainerList.Add(item);
                    }

                }
                
                
            }
        }
        public ObservableCollection<Spiel> SpielList { get; set; }
        public Spiel SelectedSpiel { get; set; }
       

        

        public ICommand SaveCommand { get; set; }
        public ICommand NewCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
        public ICommand DemoCommand { get; set; }
        public ICommand LadenCommand { get; set; }

        public ICommand AddSpielerToTeam { get; set; }
        public ICommand RemoveSpielerFromTeam { get; set; }


        Core core = null;
        public MannschaftViewModel()
        {
            core = new Core();
            
            
           
           
            MannschaftList = new ObservableCollection<Mannschaft>();
            AddSpielerToTeam = new RelayCommand(UserWantsToAddSpieler);
            RemoveSpielerFromTeam = new RelayCommand(UserWantsToRemoveSpieler);
            SaveCommand = new RelayCommand(UserWantsToSaveManschaft);
            NewCommand = new RelayCommand(UserWantsToAddNewMannschaft);
            //DeleteCommand = new RelayCommand(o => { core.UnitOfWork.GetRepo<Spieler>().Delete(SelectedSpieler); LoadSpieler(); });
            DeleteCommand = new RelayCommand(o => {
                core.UnitOfWork.GetRepo<Mannschaft>().Delete(SelectedMannschaft);
                core.UnitOfWork.SaveChanges();
                LoadMannschaft();
            });
            LadenCommand = new RelayCommand(p => LoadMannschaft());
            LoadMannschaft();
        }

        private void UserWantsToRemoveSpieler(object obj)
        {
            if (SelectedMannschaftSpieler == null) return;
            AlleSpielerExclusivManschaftSpielerList.Add(SelectedMannschaftSpieler);
            var idSpielerToRemove = SelectedMannschaftSpieler.Id;
            SpielerList.Remove(SelectedMannschaftSpieler);

            
            SelectedMannschaft.Spieler = SelectedMannschaft.Spieler.Where(s => s.Id != idSpielerToRemove).ToList();

            
        }

        private void UserWantsToAddSpieler(object obj)
        {
            if (SelectedAlleSpielerExclusivMannschaftSpieler == null) return;
            SpielerList.Add(SelectedAlleSpielerExclusivMannschaftSpieler);
            var idSpielerToAdd = SelectedAlleSpielerExclusivMannschaftSpieler.Id;
            SelectedMannschaft.Spieler.Add(SelectedAlleSpielerExclusivMannschaftSpieler);
            AlleSpielerExclusivManschaftSpielerList.Remove(SelectedAlleSpielerExclusivMannschaftSpieler);
      
        }

        private void UserWantsToAddNewMannschaft(object obj)
        {
            try
            {
                //var alleSpielerExclusivManschaftSpieler = core.UnitOfWork.SpielerRepository.GetAll().
                //                                    Where(x => !SelectedMannschaft.Spieler.Contains(x)).ToList();
                //foreach (var item in alleSpielerExclusivManschaftSpieler)
                //    AlleSpielerExclusivManschaftSpielerList.Add(item);
                
                AlleSpielerExclusivManschaftSpielerList.Clear();
                foreach (var item in core.UnitOfWork.SpielerRepository.GetAll().ToList())
                    AlleSpielerExclusivManschaftSpielerList.Add(item);
               
                var newMannschaft = new Mannschaft { Name = "NewMannschaft",
                                                    Spieler= SpielerList,
                                                     SpielAlsGast=new HashSet<Spiel>(),
                                                     SpielAlsHeim = new HashSet<Spiel>(),
                                                    };
                core.UnitOfWork.GetRepo<Mannschaft>().Add(newMannschaft);
                MannschaftList.Add(newMannschaft);

            }
            catch (Exception)
            {

                throw;
            }
        }

        private void UserWantsToSaveManschaft(object obj)
        {
            try
            {
                if (SelectedMannschaft == null) return; //TODO notify no record is selected
                Mannschaft loaded = core.UnitOfWork.GetRepo<Mannschaft>().GetById(SelectedMannschaft.Id);
                if (loaded != null) core.UnitOfWork.GetRepo<Mannschaft>().Update(SelectedMannschaft);
                else
                    core.UnitOfWork.GetRepo<Mannschaft>().Add(SelectedMannschaft);
                core.UnitOfWork.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void LoadMannschaft()
        {
            
            MannschaftList.Clear();
            foreach (var item in core.UnitOfWork.GetRepo<Mannschaft>().Query().OrderBy(x => x.Name).ToList())
            {
                MannschaftList.Add(item);

            }
            TrainerList.Clear();
                
            foreach (var item in core.UnitOfWork.GetRepo<Trainer>().Query().OrderBy(x => x.Name).ToList())
            {
                TrainerList.Add(item);

            }
        }
    }
}
