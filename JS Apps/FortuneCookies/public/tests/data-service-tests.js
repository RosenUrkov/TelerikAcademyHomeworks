import { DataService } from 'data-service';
const dataService = new DataService();
const expect = chai.expect;

describe("Data-service tests", function() {
    it("Expect data-service to be an object", function() {
        expect(dataService).to.be.an('object');
    });
    it("Expect data-service to have correct property 'header'", function() {
        expect(dataService.header).to.equal('x-auth-key');
    });
    describe("getUserData tests", function() {
        it("Expect data-service to have function getUserData", function() {
            expect(dataService.getUserData).to.be.an('function');
        });
        it("Expect getUserData to return object with username and passHash", function() {
            const user = dataService.getUserData();

            expect(user).to.be.an('object');
            expect(user).to.haveOwnProperty('username')
            expect(user).to.haveOwnProperty('passHash');
        });
    });
    describe("getCookieData tests", function() {
        it("Expect data-service to have function getCookieData", function() {
            expect(dataService.getUserData).to.be.an('function');
        });
        it("Expect getCookieData to return object with text, category and img", function() {
            const cookie = dataService.getCookieData();

            expect(cookie).to.be.an('object');
            expect(cookie).to.haveOwnProperty('text')
            expect(cookie).to.haveOwnProperty('category');
            expect(cookie).to.haveOwnProperty('img');
        });
    });
});