using Core.Entities.Concrete;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Business.Constants.Messages
{
    public static class Messages
    {
        public static string CarAdded = "Car added successfully";
        public static string CarNameInvalid = "Car name invalid";
        public static string DailyPriceInvalid = "Daily price invalid";
        public static string CarDeleted = "Car deleted successfully";
        public static string CarUpdated = "Car updated successfully";
        public static string CarsListed = "Cars listed successfully";

        public static string BrandAdded = "Brand added successfully";
        public static string BrandDeleted = "Brand deleted successfully";
        public static string BrandUpdated = "Brand updated successfully";
        public static string BrandsListed = "Brands listed successfully";

        public static string ColorAdded = "Color added successfully";
        public static string ColorDeleted = "Color deleted successfully";
        public static string ColorUpdated = "Color updated successfully";
        public static string ColorsListed = "Colors listed successfully";

        public static string UserAdded = "User added successfully";
        public static string UserDeleted = "User deleted successfully";
        public static string UserUpdated = "User updated successfully";
        public static string UsersListed = "Users listed successfully";
        public static string UserNotFound = "User not found";

        public static string CustomerAdded = "Customer added successfully";
        public static string CustomerDeleted = "Customer deleted successfully";
        public static string CustomerUpdated = "Customer updated successfully";
        public static string CustomersListed = "Customers listed successfully";

        public static string RentalAdded = "Rental added successfully";
        public static string RentalDeleted = "Rental deleted successfully";
        public static string RentalUpdated = "Rental updated successfully";
        public static string RentalsListed = "Rentals listed successfully";
        public static string OperationFailed = "Operation failed";
        public static string CarNotAvailable = "Car is not available";

        public static string CarImageAdded = "Image added successfully";
        public static string CarImageDeleted = "Image deleted successfully";
        public static string CarImageUpdated = "Image updated successfully";
        public static string CarImagesListed = "Car Images listed successfully";
        public static string DefaultImageDisplayed = "Default image displayed";
        public static string DefaultImageNotFound = "Default image not found";
        public static string PasswordError = "Password error";
        public static string SuccessfulLogin = "Login successful";
        public static string UserAlreadyExists = "User already exists";
        public static string UserRegistered = "User successfully registered";

        public static string AccessTokenCreated = "Access token created successfully";

        public static string AuthorizationDenied = "You are not authorized";

        public static string CarNameAlreadyExists = "Car name already exists";
    }
}
