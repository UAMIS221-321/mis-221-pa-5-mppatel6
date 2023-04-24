using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mis_221_pa_5_mppatel6
{
    public class ListingReport
    {
        Listing[] listings;

        public ListingReport(Listing[] listings){
            this.listings = listings;

        }

        public void PrintAllListings(){
            for(int i = 0; i < Listing.GetCount(); i++){
                if(listings[i].GetDeleted() == false){
                    System.Console.WriteLine(listings[i].ToString());
                }
            }
        }

        public void PrintOpenListing(){
            for(int i = 0; i < Listing.GetCount(); i++){
                if(listings[i].GetDeleted() == false){
                    if(listings[i].GetTaken() == "Open"){
                        System.Console.WriteLine(listings[i].ToString());
                    }
                }
            }
        }
        public int CountOpenListings(){
            int count = 0;
            for(int i = 0; i < Listing.GetCount(); i++){
                if(listings[i].GetDeleted() == false){
                    if(listings[i].GetTaken() == "Open"){
                        System.Console.WriteLine(listings[i].ToString());
                        count++;
                    }
                }
            }

            return count;
        }
    }
}