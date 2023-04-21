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

        static private int count;

        public Workout(){
            
        }
        public Workout(string workout, string repRange, string restTime, string url, string workoutType){
            this.workout = workout;
            this.repRange = repRange;
            this.restTime = restTime;
            this.url = url;
            this.workoutType = workoutType;
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
        static public int GetCount(){
            return Workout.count;
        }
        static public void SetCount(){
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
    }
}