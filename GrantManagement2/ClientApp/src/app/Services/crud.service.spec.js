"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var testing_1 = require("@angular/core/testing");
var crud_service_1 = require("./crud.service");
describe('CrudService', function () {
    beforeEach(function () { return testing_1.TestBed.configureTestingModule({}); });
    it('should be created', function () {
        var service = testing_1.TestBed.get(crud_service_1.CrudService);
        expect(service).toBeTruthy();
    });
});
//# sourceMappingURL=crud.service.spec.js.map