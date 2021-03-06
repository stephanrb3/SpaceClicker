﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Code{
    public class Resources{
        // RESOURCES:
        // 0 : WATER
        // 1 : FOOD
        // 2 : POWER
        // 3 : TITANIUM
        // 4 : IRIDIUM
        // 5 : KHYBERIUM

        public static int NUM_OF_RESOURCES = 6;
        
    
        private int[] resources;

        public Resources(){
            resources = new int[NUM_OF_RESOURCES];
            for(int i = 0; i < resources.Length; i++)
                resources[i] = 0;
        }
        public Resources(int[] resourcesArray){
            resources = new int[NUM_OF_RESOURCES];
            for(int i = 0; i < resources.Length; i++){
                resources[i] = resourcesArray[i];
            }
        }
        public static Resources EarthResourceGeneration(){
            return new Resources(new int[] {5,5,5,5,5,5});
        }
        public static Resources WaterResourceGeneration(){
            return new Resources(new int[] {10,10,5,0,0,0});
        }
        public static Resources SandResourceGeneration(){
            return new Resources(new int[] {0,0,0,10,10,10});
        }
        public static Resources DarkResourceGeneration(){
            return new Resources(new int[] {0,0,10,5,5,5});
        }
        public static Resources BuildingResourceOptimizer(string planetName, int[] buildings){
            //if(buildings.Length != BuildingView.BUILDING_NAMES.Length)
                //return null;
            if(planetName == "Earth-Planet")// WATER                                      FOOD
                return new Resources(new int[]{(int)Mathf.Pow((float)1.5, buildings[4]), (int)Mathf.Pow((float)1.5, buildings[2]), (int)Mathf.Pow((float)2, buildings[0]),(int)Mathf.Pow((float)1.5, buildings[1]),(int)Mathf.Pow((float)1.5, buildings[1]),(int)Mathf.Pow((float)1.5, buildings[5])});
            if(planetName == "Water-Planet")
                return new Resources(new int[]{(int)Mathf.Pow((float)2, buildings[4]), (int)Mathf.Pow((float)0, buildings[2]), (int)Mathf.Pow((float)0, buildings[0]),(int)Mathf.Pow((float)0, buildings[1]),(int)Mathf.Pow((float)0, buildings[1]),(int)Mathf.Pow((float)0, buildings[5])});
            if(planetName == "Sand-Planet")
                return new Resources(new int[]{(int)Mathf.Pow((float)0, buildings[4]), (int)Mathf.Pow((float)0, buildings[2]), (int)Mathf.Pow((float)1.5, buildings[0]),(int)Mathf.Pow((float)1.5, buildings[1]),(int)Mathf.Pow((float)1.5, buildings[1]),(int)Mathf.Pow((float)2, buildings[5])});
            if(planetName == "Dark-Planet")               
                return new Resources(new int[]{(int)Mathf.Pow((float)0, buildings[4]), (int)Mathf.Pow((float)0, buildings[2]), (int)Mathf.Pow((float)2, buildings[0]),(int)Mathf.Pow((float)1.5, buildings[1]+buildings[5]),(int)Mathf.Pow((float)1.5, buildings[1] + buildings[5]),(int)Mathf.Pow((float)1.75, buildings[5])});
            return new Resources();
        }
        public static Resources GetPlanetResourceGeneration(string planetName){
            if(planetName == "Earth-Planet")
                return EarthResourceGeneration();
            if(planetName == "Water-Planet")
                return WaterResourceGeneration();
            if(planetName == "Sand-Planet")
                return SandResourceGeneration();
            if(planetName == "Dark-Planet")
                return DarkResourceGeneration();
            return new Resources();
        }
        public static Resources GetOptimizedPlanetGeneration(string planetName, int[] buildings){
            Resources planetResources = GetPlanetResourceGeneration(planetName);
            Resources optimizedBuildingResources = BuildingResourceOptimizer(planetName, buildings);
            return planetResources.addResources(optimizedBuildingResources);
        }

        public bool compareCost(string buildName)
        {
            int[] toCheck = getCost(buildName);
            bool toRet = true;
            for (int i = 0; i < resources.Length ; i++)
            {
                if (resources[i] < toCheck[i])
                    toRet = false;
            }

            return toRet;
        }

        public void removeCost(string buildName)
        {
            int[] toRemove = getCost(buildName);
            for (int i = 0; i < toRemove.Length; i++)
            {
                resources[i] -= toRemove[i];
            }
        }

        public int[] getCost(string buildName)
        {
            int[] toRet = new int[6];
            if (buildName == "Power")
            {
                toRet[0] = 5;
                toRet[1] = 5;
                toRet[2] = 5;
                toRet[3] = 5;
                toRet[4] = 5;
                toRet[5] = 5;

                return toRet;
            }
            if (buildName == "Mine")
            {
                toRet[0] = 5;
                toRet[1] = 5;
                toRet[2] = 5;
                toRet[3] = 5;
                toRet[4] = 5;
                toRet[5] = 5;

                return toRet;
            }
            if (buildName == "Farm")
            {
                toRet[0] = 5;
                toRet[1] = 5;
                toRet[2] = 5;
                toRet[3] = 5;
                toRet[4] = 5;
                toRet[5] = 5;

                return toRet;
            }
            if (buildName == "Habitation")
            {
                toRet[0] = 5;
                toRet[1] = 5;
                toRet[2] = 5;
                toRet[3] = 5;
                toRet[4] = 5;
                toRet[5] = 5;

                return toRet;
            }
            if (buildName == "WTF")
            {
                toRet[0] = 5;
                toRet[1] = 5;
                toRet[2] = 5;
                toRet[3] = 5;
                toRet[4] = 5;
                toRet[5] = 5;

                return toRet;
            }
            if (buildName == "Synth")
            {
                toRet[0] = 1;
                toRet[1] = 1;
                toRet[2] = 1;
                toRet[3] = 1;
                toRet[4] = 1;
                toRet[5] = 1;

                return toRet;
            }
            return null;
        }

        public int[] GetResources(){
            return resources;
        }
        public Resources addResources(Resources addedResources){
            for(int i = 0; i < resources.Length; i++){
                resources[i] += addedResources.GetResources()[i];
            }
            return new Resources(resources);
        }

        public void removeResources(Resources removedResources){
            for(int i = 0; i < resources.Length; i++){
                resources[i] -= removedResources.GetResources()[i];
            }
        }
        public int GetWater(){
            return resources[0];
        }
        public int GetFood(){
            return resources[1];
        }
        public int GetPower(){
            return resources[2];
        }
        public int GetTitanium(){
            return resources[3];
        }
        public int GetIridium(){
            return resources[4];
        }
        public int GetKhyber(){
            return resources[5];
        }
        public void SetWater(int water){
            resources[0] = water;
        }
        public void SetFood(int food){
            resources[1] = food;
        }
        public void SetPower(int power){
            resources[2] = power;
        }
        public void SetTitanium(int titanium){
            resources[3] = titanium;
        }
        public void SetIridium(int iridium){
            resources[4] = iridium;
        }
        public void SetKhyber(int khyber){
            resources[5] = khyber;
        }

    }
}