using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mis_221_pa_5_mppatel6
{
    public class Listing
    {
        private int listingID;
        private string trainerName;
        private string date;
        private string time;
        private int cost;
        private string taken;
        private bool deleted;

        static private int count;

        public Listing(){

        }
        public Listing(int listingID, string trainerName, string date, string time, int cost, string taken, bool deleted){
            this.listingID = listingID;
            this.trainerName = trainerName;
            this.date = date;
            this.time = time;
            this.cost = cost;
            this.taken = taken;
            this.deleted = deleted;
        }

        public int GetListingID(){
            return listingID;
        }

        public void SetListingID(){
            this.listingID = count + 1;
        }
        public string GetTrainerName(){
            return trainerName;
        }
        public void SetTrainerName(string trainerName){
            this.trainerName = trainerName;
        }
        public string GetDate(){
            return date;
        }
        public void SetDate(string date){
            this.date = date;
        }
        public string GetTime(){
            return time;
        }
        public void SetTime(string time){
            this.time = time;
        }
        public int GetCost(){
            return cost;
        }
        public void SetCost(int cost){
            this.cost = cost;
        }
        public string GetTaken(){
            return taken;
        }
        public void SetTaken(string taken){
            this.taken = taken;
        }
        static public int GetCount(){
            return Listing.count;
        }
        static public void SetCount(int count){
            Listing.count = count;
        }

        static public void IncCount(){
            Listing.count++;
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
                return String.Format($"{listingID, -0} {trainerName, -20} {date, -20} {time, -20} ${cost, -20} {taken, -20}");
            }
            return "";
        }

        public string ToFile()
        {
            return $"{listingID}#{trainerName}#{date}#{time}#{cost}#{taken}#{deleted}";
        }
    }
}