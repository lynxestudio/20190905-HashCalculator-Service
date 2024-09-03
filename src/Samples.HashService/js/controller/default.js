app.controller("AppCtrl", ['$scope','$http',AppCtrl]);

function AppCtrl($scope, $http) {
    $scope.title = "AngularJS/WCF Hash Calc";
    $scope.showError = false;
    $scope.hashtype = "MD5";
    $scope.GetHashCode = function () {
        if ($scope.text === undefined || $scope.text == ' ') {
            $scope.showError = true;
        }
        else {
            console.log("sending request...");

            var url = "http://localhost:23361/HashService.svc/hash";
            var data = {
                "rq": {
                    "HashType": $scope.hashtype,
                    "Text": $scope.text
                }
            };
            var config = {
                dataType: "json",
                method: "POST",
                headers: { "Content-Type": "application/json" }
            };
            $http.post(url, data, config)
                .then(function (response, status) {
                    if (response.data.Code == 200) {
                        $scope.hashcode = response.data.HashCode
                        $scope.showError = false;
                    }
                }, function (response, status) {
                    console.log("Url " + url);
                    console.log("Status " + status);
                    console.log("REsponse " + response);
                });
        }
    };
}