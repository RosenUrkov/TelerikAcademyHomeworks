import { Requester } from 'requester';

const requester = new Requester();
const expect = chai.expect;

describe("Requester tests", function() {
    it("Expect requester to be an object", function() {
        expect(requester).to.be.an('object');
    });
    describe("getJSON tests", function() {
        it("Expect requester to have funciton getJSON", function() {
            expect(requester.getJSON).to.be.an('function');
        });
        it("Expect getJSON to call jQuery.ajax function once", function() {
            const ajaxStub = sinon.stub($, 'ajax');

            requester.getJSON('anyURL');

            expect(ajaxStub.calledOnce).to.be.true;

            ajaxStub.restore();
        });
        it("Expect getJSON to pass correct headers to the request", function() {
            const ajaxStub = sinon.stub($, 'ajax'),
                headers = {
                    myHeader: 42
                };

            requester.getJSON('anyURL', headers);

            const passedObject = ajaxStub.args[0][0];
            expect(passedObject.headers).to.deep.eq(headers);

            ajaxStub.restore();
        });
        it("Expect getJSON to be passed an object with correct properties", function() {
            const ajaxStub = sinon.stub($, 'ajax'),
                url = 'myUrl';

            requester.getJSON(url);

            const passedObject = ajaxStub.args[0][0];

            expect(passedObject).to.be.an('object');
            expect(passedObject.type).to.equal('GET');
            expect(passedObject.url).to.equal(url);

            ajaxStub.restore();
        });
        it("Expect getJSON to return promise", function() {
            const ajaxStub = sinon.stub($, 'ajax');

            const promise = requester.getJSON('anyURL');

            expect(promise).to.be.instanceof(Promise);

            ajaxStub.restore();
        })
    });
});