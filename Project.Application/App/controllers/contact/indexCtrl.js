contactMdl.controller("indexCtrl", ['$scope', 'globalSvc', 'contactSrv',
    function ($scope, globalSvc, contactSrv) {
        $scope.grid = {};

        filter = {
            filterType: '',
            filterName: ''
        }

        $scope.letters = [
            {
                letter: 'ALL',
                isActive: false
            },
            {
                letter: 'A',
                isActive: false
            },
            {
                letter: 'B',
                isActive: false
            },
            {
                letter: 'C',
                isActive: false
            },
            {
                letter: 'D',
                isActive: false
            },
            {
                letter: 'E',
                isActive: false
            },
            {
                letter: 'F',
                isActive: false
            },
            {
                letter: 'G',
                isActive: false
            },
            {
                letter: 'H',
                isActive: false
            },
            {
                letter: 'I',
                isActive: false
            },
            {
                letter: 'J',
                isActive: false
            },
            {
                letter: 'K',
                isActive: false
            },
            {
                letter: 'L',
                isActive: false
            },
            {
                letter: 'M',
                isActive: false
            },
            {
                letter: 'N',
                isActive: false
            },
            {
                letter: 'O',
                isActive: false
            },
            {
                letter: 'P',
                isActive: false
            },
            {
                letter: 'Q',
                isActive: false
            },
            {
                letter: 'R',
                isActive: false
            },
            {
                letter: 'S',
                isActive: false
            },
            {
                letter: 'T',
                isActive: false
            },
            {
                letter: 'U',
                isActive: false
            },
            {
                letter: 'V',
                isActive: false
            },
            {
                letter: 'W',
                isActive: false
            },
            {
                letter: 'x',
                isActive: false
            },
            {
                letter: 'Y',
                isActive: false
            },
            {
                letter: 'Z',
                isActive: false
            }];

        //globalSvc.showMessage.set('Apenas um Teste', 'danger');

        var customGrid = {
            firstLetter: 'ALL',
            search: '',
            pageIndex: 0,
            pageSize: 10,
            sortName: 'Name',
            sortDirection: 'ASC',
        };

        $scope.grid = {
            useExternalPagination: true,
            useExternalSorting: true,
            enableRowSelection: false,
            enableSelectAll: true,
            paginationPageSizes: [10, 20, 50, 100],
            pageNumber: 1,
            pageSize: 10,
            i18n: 'pt-br',
            data: '',

            columnDefs: [
                { name: 'Name', field: 'Name', width: '30%' },
                { name: 'E-mail', field: 'Email', width: '20%' },
                { name: 'CellPhone', field: 'CellPhone' },
                { name: 'Commercial Phone', field: 'CommercialPhone' },
                { name: 'Home Phone', field: 'homePhone' },
                { name: 'Add Date', field: 'AddDate', cellFilter: 'filterDate' }
            ],

            onRegisterApi: function (gridApi) {

                $scope.gridApi = gridApi;

                gridApi.pagination.on.paginationChanged($scope, function (newPage, pageSize) {
                    customGrid.PageSize = pageSize;
                    customGrid.PageIndex = (newPage - 1) * pageSize;
                    $scope.getContacts();
                });

                gridApi.core.on.sortChanged($scope, function (grid, sortColumns) {
                    if (sortColumns.length > 0) {
                        customGrid.SortName = sortColumns[0].name;
                        customGrid.SortDirection = sortColumns[0].sort.direction;
                        $scope.getContacts(customGrid);
                    }
                });

            }
        };

        $scope.getContacts = function () {

            contactSrv.getAll(customGrid).then(function (response) {
                $scope.grid.data = response.data.result;
                $scope.grid.totalItems = response.data.count;
                console.log(response);
            });

        };

        $scope.changeContacts = function (letter, search) {

            customGrid.FirstLetter = letter.letter;
            customGrid.Search = search;
            $scope.getContacts();

            $scope.letters.forEach(letter => { letter.isActive = false });
            letter.isActive = true;

        };

        $scope.clearSearch = function () {

            $scope.textSearch = '';
            $scope.changeContacts('ALL', '');

        };


        $scope.init = function () {
            $scope.pageTitle = "Contact List"
            $scope.message = globalSvc.showMessage.get();
            $scope.getContacts();
        };

        $scope.init();

    }
]);