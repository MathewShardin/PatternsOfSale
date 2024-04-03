﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Threading.Tasks;

namespace PatternsOfSale.Models
{
    public class EasyCustomer : Customer
    {
        public EasyCustomer(int numOfDishes) : base(numOfDishes)
        {
            Assignment newAss = new Assignment();
            newAss.AddDishes(numOfDishes);
            this.assignment = newAss;
        }

        public override double CheckAssignment(List<ItemInterface> input, long time)
        {
            double finalScore = 0;
            double scoreMultiplier = getScoreMultiplier(time);
            double points = assignment.CheckAssCompletion(input);

            finalScore = points * scoreMultiplier;

            return finalScore;
        }  
    
    }

}
