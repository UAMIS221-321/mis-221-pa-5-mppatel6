using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mis_221_pa_5_mppatel6
{
    public class TrainerReport
    {
        private Trainer[] trainers;

        public TrainerReport(Trainer[] trainers){
            this.trainers = trainers;

        }

        public void PrintAllTrainers(){ // reports all the trainers
            for(int i = 0; i < Trainer.GetCount(); i++){
                if(trainers[i].GetDeleted() == false){
                    System.Console.WriteLine(trainers[i].ToString());
                }
            }
        }
    }
}