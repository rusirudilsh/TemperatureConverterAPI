# Temperature Converter API
This is the Web API back-end project of the Temperature Converter Solution

Instructions to set up the project locally

1. Clone the repo
2. Do a Nuget package restore
3. Run the app on the local IIS server


Note: Since this is involving a pre-defined requirement for converting values only between 3 types of temperature, For simplicity, I'm using a static class to do the calculations and return the result. But the best practice is to use an abstract Base class and have the different sub-classes derived from the base class and override the relevant method which does the conversions. The base class will have the required properties and methods encapsulated inside. So this way, you don't have to modify the base class when the requirement changes to support conversations between other temperature types as well. Instead, you only have to create new classes derived from the base class and implement the abstract methods. 
