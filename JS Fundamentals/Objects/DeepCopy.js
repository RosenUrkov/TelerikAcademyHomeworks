function solve(args) {

    var obj1 = { name: 'Benjamin', age: 'baligo', asd: { inception: 'wow' } },
        obj2 = {};

    for (prop in obj1) {
        if ((typeof obj1[prop]) === 'object') {
            for (pro in prop) {
                obj2[prop][pro] = obj1[prop][pro];
            }
        } else {
            obj2[prop] = obj1[prop];
        }
    }

    console.log(obj2.asd.inception);
    obj1.asd.inception = 'lol';
    console.log(obj2.asd.inception);

}

solve();