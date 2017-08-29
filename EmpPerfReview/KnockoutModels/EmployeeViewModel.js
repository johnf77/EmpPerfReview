var employeeViewModel;

function Employee(id, firstName, lastName, age, gender, empRole, detail, employeeId) {
    var self = this;

    // observable are update elements upon changes, also update on element data changes [two way binding]
    self.Id = ko.observable(id);
    self.FirstName = ko.observable(firstName);
    self.LastName = ko.observable(lastName);
    self.EmpRole = ko.observable(empRole);

    self.FullName = ko.computed(function () {
        return self.FirstName() + " " + self.LastName();
    }, self);

    self.Age = ko.observable(age);
    self.Gender = ko.observable(gender);

    // Non-editable catalog data - should come from the server
    self.genders = [
        "Male",
        "Female"
    ];

    self.roles = [
        "Admin",
        "Employee"
    ];

    //get from server - and display name
    self.employeeList = [
        "1",
        "2"
    ];
   

    self.Detail = ko.observable(detail);
    self.EmployeeId = ko.observable(employeeId);

    self.addEmployee = function () {
        var dataObject = ko.toJSON(this);

        // remove computed field from JSON data which server is not expecting
        delete dataObject.FullName;

        $.ajax({
            url: '/api/Employees',
            type: 'post',
            data: dataObject,
            contentType: 'application/json',
            success: function (data) {
                employeeViewModel.addEmployeeViewModel.push(new Employee(data.Id, data.FirstName, data.LastName, data.Age, data.Gender, data.EmpRole));

                self.Id(null);
                self.FirstName('');
                self.LastName('');
                self.Age('');
                self.EmpRole('');
            }
        });
    };
}

function EmployeeList(id, detail, employeeId) {

    var self = this;
    self.reviews = ko.observableArray([]);
    self.Id = ko.observable(id);
    self.Detail = ko.observable(detail);
    self.EmployeeId = ko.observable(employeeId);

    // observable arrays are update binding elements upon array changes
    self.employees = ko.observableArray([]);

    self.getEmployees = function () {
        self.employees.removeAll();

        // retrieve employees list from server side and push each object to model's employees list
        $.getJSON('/api/Employees', function (data) {
            $.each(data, function (key, value) {
                self.employees.push(new Employee(value.Id, value.FirstName, value.LastName, value.Age, value.Gender, value.EmpRole, value.Detail, value.EmployeeId));
            });
        });
    };


    // remove employee. current data context object is passed to function automatically.
    self.removeEmployee = function (employee) {
        $.ajax({
            url: '/api/Employees/' + employee.Id(),
            type: 'delete',
            contentType: 'application/json',
            success: function () {
                self.employees.remove(employee);
            }
        });
    };

    self.updateReview = function (review) {
        $.ajax({
            url: '/api/Reviews/' + review.Id(),
            type: 'put',
            data: ko.toJSON(review),
            contentType: 'application/json',
            success: function () {
            }
        });
    };

    self.getReviews = function () {
        self.reviews.removeAll();

        // retrieve reviews list from server side and push each object to model's reviews list
        $.getJSON('/api/Reviews', function (data) {
            $.each(data, function (key, value) {
                self.reviews.push(new Review(value.Id, value.Detail, value.EmployeeId));
            });
        });
    };
}

var reviewViewModel;

function Review(id, detail, employeeId) {
        var self = this;

        // observable are update elements upon changes, also update on element data changes [two way binding]
        self.Id = ko.observable(id);
        self.Detail = ko.observable(detail);
        self.EmployeeId = ko.observable(employeeId);

        //get from server
        self.assignees = [
           "1",
           "2"
        ];

        self.addReview = function () {
            var dataObject = ko.toJSON(this);

            $.ajax({
                url: '/api/Reviews',
                type: 'post',
                data: dataObject,
                contentType: 'application/json',
                success: function (data) {
                    reviewViewModel.addReviewViewModel.push(new Review(data.Id, data.Detail, data.EmployeeId));

                    self.Id(null);
                    self.Detail('');
                    self.EmployeeId('');
                }
            });
        };
    }

function ReviewList() {

        var self = this;

        // observable arrays are update binding elements upon array changes
        self.reviews = ko.observableArray([]);

        self.getReviews = function () {
            self.reviews.removeAll();

            // retrieve reviews list from server side and push each object to model's reviews list
            $.getJSON('/api/Reviews', function (data) {
                $.each(data, function (key, value) {
                    self.reviews.push(new Review(value.Id, value.Detail, value.EmployeeId));
                });
            });
        };


        // remove review. current data context object is passed to function automatically.
        self.removeReview = function (review) {
            $.ajax({
                url: '/api/Reviews/' + review.Id(),
                type: 'delete',
                contentType: 'application/json',
                success: function () {
                    self.reviews.remove(review);
                }
            });
        };
}

function EmployeeReview(id, detail, employeeId) {

        var self = this;

        self.reviews = ko.observableArray([]);
        self.Id = ko.observable(id);
        self.Detail = ko.observable(detail);
        self.EmployeeId = ko.observable(employeeId);

        self.getAReview = function (val) {
            self.reviews.removeAll();

            // retrieve review from server side and push each object to model's reviews list
            $.getJSON('/api/Reviews/' + val, function (data) {
                self.reviews.push(new Review(data.Id, data.Detail, data.EmployeeId));
            });
        };       
    }

    // create index view view model which contain two models for partial views
    employeeViewModel = {
        addEmployeeViewModel: new Employee(), employeeListViewModel: new EmployeeList(),
        employeeReviewViewModel: new EmployeeReview(), reviewListViewModel: new ReviewList()
    };

    $(document).ready(function () {

        // bind view model to referring view
        ko.applyBindings(employeeViewModel);

        // load data
        employeeViewModel.employeeListViewModel.getEmployees();
        employeeViewModel.reviewListViewModel.getReviews();

    });
