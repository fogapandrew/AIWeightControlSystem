# AI Weight Control System

## Table of Contents
- Introduction
- Problem Definition
- Thinking Process and Algorithms
    - KNN Classification
    - Multi Linear Regression
- Challenges Faced
- Ethical Aspects
- Sources
  
## Introduction
The AI Weight Control System is a machine learning project aimed at assisting individuals, particularly international students, in managing their dietary habits to maintain a healthy weight. The system utilizes data on food ingredients to predict their weight contributions, thereby empowering users to make informed decisions about their dietary choices.

## Problem Definition
The project was initiated based on personal experiences of weight gain attributed to dietary changes after relocating to Belgium. The objective is to develop a machine learning model capable of predicting the weight contributions of various food ingredients. By analyzing features such as calories, fiber content, and taste ratings, the system aims to provide users with insights into the impact of different ingredients on their overall diet.

## Thinking Process and Algorithms
### KNN Classification
The K Nearest Neighbors (KNN) algorithm was chosen for its suitability in supervised learning scenarios with categorical output. Below is the thinking process involved in implementing KNN for this project:
- Data Preprocessing: Cleaned the dataset and organized features.
- Dictionary Creation: Created a dictionary mapping ingredients to unique codes for efficient calculation.
- Distance Calculation: Implemented a method to calculate distances between input features and dataset entries.
- Prediction: Utilized KNN to classify the input based on its nearest neighbors.
- Implementation: Developed methods to handle user inputs and provide predictions.
  
### Multi Linear Regression
Multi Linear Regression was selected to quantify relationships between multiple features and the target variable (weight contribution). Here's the thought process behind implementing this algorithm:
- Data Preparation: Cleaned and organized the dataset.
- Feature Extraction: Extracted features and target variable from the dataset.
- Dictionary Creation: Established a dictionary for ingredient codes to ensure consistency.
- Regression Sum Calculation: Computed various regression sums required for coefficient estimation.
- Coefficient Estimation: Calculated regression coefficients using the provided formula.
- Prediction: Implemented a function to predict weight contributions based on user inputs.


## Challenges Faced
- Data Availability: Obtaining adequate data was challenging, necessitating the creation of dummy datasets.
- Resource Constraints: Accessing resources for KNN implementation posed difficulties initially.
- Mathematical Formulas: Understanding and applying the exact formulas for coefficient calculation in multi linear regression required effort.

## Ethical Aspects
- Privacy Concerns: The system must ensure user privacy, especially concerning health-related data.
- Bias and Discrimination: Care must be taken to address biases in ingredient selection to avoid cultural or racial discrimination.
- Accuracy and Representativeness: Due to the complexity of data collection, achieving accurate predictions may be challenging, affecting the system's representativeness.
  
## Sources
Statology - Multiple Linear Regression by Hand
Medium - K Nearest Neighbor
C# Corner - Machine Learning: KNN (K Nearest Neighbors)
Towards Data Science - Using K Nearest Neighbours to Predict the Genre of Spotify Tracks
University of Colorado Boulder - Lesson 12: Multiple Regression
