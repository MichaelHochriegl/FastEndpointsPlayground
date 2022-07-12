## Rough steps to forget nothing

1. Create empty Solution
2. Create folder structure
3. Create `Contract` project, this will hold the actual API contracts for e.g. a Blog post
4. Install `FluentValidation` for the `Contract` project
5. Create the folder for the first feature, e.g. `Blogs/Create`
6. Create `Constants` class inside the `Blogs` folder, this will hold validation limits for our feature
7. Create `Models` class inside the feature folder, this class will hold the request and response models
8. Create `Validator` class inside the feature folder, this class will hold the validator for the request
9. Create `IContractMarker` interface inside the `Contract` project, this will be used to get the assembly scanning
10. Inside the `Backend` folder create a new ASP.Net core web api project
