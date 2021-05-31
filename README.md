# Temperature Converter API
This is the Web API back end project of the Temperature Converter Solution

Instructions to set up the project locally

1. Clone the repo
2. Do a nuget package restore
3. Run the app on local IIS server


Note: Since this is involving pre defined requirement for convert values only between 3 types of temperature, For the simplicity, I'm using a static class to do the calculations and return the result. But the best practice is to use an abstract Base class and have the different clients derived from the base class and override the revlevant method which do the convertions. Base class will have required properties and methods encapsulated inside. So this way, you don't have to modify the base class when requirement changes to support convertions between other temperature types as well. Instead, you only have to create new classes derived from base class and implement the abstract methods. 
