using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mis_221_pa_5_mppatel6
{
    public class Workout
    {
        private string workout;
        private string repRange;
        private string restTime;
        private string url;
        private string workoutType;
        private string status;

        static private int count;

        public Workout(){
            
        }
        public Workout(string workout, string repRange, string restTime, string url, string workoutType,string status){
            this.workout = workout;
            this.repRange = repRange;
            this.restTime = restTime;
            this.url = url;
            this.workoutType = workoutType;
            this.status = status;
        }
        public string GetWorkout(){
            return workout;
        }
        public void SetWorkout(string workout){
            this.workout = workout;
        }
        public string GetRepRange(){
            return workout;
        }
        public void SetRepRange(string repRange){
            this.repRange = repRange;
        }
        public string GetRestTime(){
            return workout;
        }
        public void SetRestTime(string restTime){
            this.restTime = restTime;
        }
        public string GetURL(){
            return url;
        }
        public void SetURL(string url){
            this.url = url;
        }
        public string GetWorkoutType(){
            return workoutType;
        }
        public void SetWorkoutType(string workoutType){
            this.workoutType = workoutType;
        }
        public string GetStatus(){
            return status;
        }
        public void SetStatus(string status){
            this.status = status;
        }
        static public int GetCount(){
            return Workout.count;
        }
        static public void SetCount(int count){
            Workout.count = count;
        }
        static public void IncCount(){
            Workout.count++;
        }
        public override string ToString()
        {
            return $@"
            Workout: {workout}
            Rep Range: {repRange}
            Rest Time: {restTime}
            Tutorial: {url}
            ";
        }
        public string ToFile()
        {
            return $"{workout}#{repRange}#{restTime}#{url}#{workoutType}#{status}";
        }
    }
}