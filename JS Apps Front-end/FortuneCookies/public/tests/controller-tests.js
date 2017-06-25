import { Controller } from 'controller';
const controller = new Controller();
const expect = chai.expect;

describe('Controller tests', function() {
    it('Expect controller to be an object', function() {
        expect(controller).to.be.an('object');
    });
});