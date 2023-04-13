using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mis_221_pa_5_mppatel6
{
    public class Trainer
    {
        private int trainerID;
        
        private string trainerName;
        private string  mailingAddress;
        private string emailAddress;
        private bool deleted;

        static private int count;

        public Trainer(){
            
        }

        public Trainer(int trainerID, string trainerName, string mailingAddress, string emailAddress, bool deleted){
            this.trainerID = trainerID;
            this.trainerName = trainerName;
            this.mailingAddress = mailingAddress;
            this.emailAddress = emailAddress;
            this.deleted = deleted;
        }

        public int GetID(){
            return trainerID;
        }
        public void SetID(){
            this.trainerID = count + 1;
        }
        public string GetTrainerName(){
            return trainerName;
        }
        public void SetTrainerName(string trainerName){
            this.trainerName = trainerName;
        }
        public string GetMailingAddress(){
            return mailingAddress;
        }
        public void SetMailingAddress(string mailingAddress){
            this.mailingAddress = mailingAddress;
        }
        public string GetEmailAddress(string emailAddress){
            return emailAddress;
        }
        public void SetEmailAddress(string emailAddress){
            this.emailAddress = emailAddress;
        }
        static public int GetCount(){
            return Trainer.count;
        }
        static public void SetCount(int count){
            Trainer.count = count;
        }

        static public void IncCount(){
            Trainer.count++;
        }
        public bool GetDeleted(){
            return deleted;
        }
        public void Delete(){
            deleted = true;
        }

        public override string ToString()
        {
            if(deleted == false){
                return String.Format($"{trainerID, -0}  {trainerName, -20}  {mailingAddress, -40}  {emailAddress, -40}");
            }
            return "";
        }

        public string ToFile()
        {
            return $"{trainerID}#{trainerName}#{mailingAddress}#{emailAddress}#{deleted}";
        }

    }
}