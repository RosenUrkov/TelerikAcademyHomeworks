(function solve() {
    new Promise((resolve, reject) => navigator.geolocation.getCurrentPosition(resolve))
        .then(x => ({ lat: x.coords.latitude, long: x.coords.longitude }))
        .then(x => {
            const src = `http://maps.googleapis.com/maps/api/staticmap?center=${x.lat},${x.long}&zoom=18&size=500x500&sensor=false`;
            document.getElementById('map').src = src;
        })
        .catch(console.log);
}());