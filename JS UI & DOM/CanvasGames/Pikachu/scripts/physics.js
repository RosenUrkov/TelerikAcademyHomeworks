function createPhysicalBody(options) {

    function move() {
        const self = this,
            lastCoordinates = JSON.parse(JSON.stringify(self.coordinates));

        self.coordinates.x += self.speed.x;
        self.coordinates.y += self.speed.y;

        return lastCoordinates;
    }

    function collidesWith(otherPhysicalBody) {
        const self = this,
            x1 = self.coordinates.x + self.width / 2,
            y1 = self.coordinates.y + self.height / 2,
            x2 = otherPhysicalBody.coordinates.x + otherPhysicalBody.width / 2,
            y2 = otherPhysicalBody.coordinates.y + otherPhysicalBody.height / 2,
            distance = Math.sqrt((x1 - x2) * (x1 - x2) + (y1 - y2) * (y1 - y2));

        return distance <= (self.radius + otherPhysicalBody.radius);
    }

    const physicalBody = {
        coordinates: options.coordinates,
        width: options.width,
        height: options.height,
        radius: (options.width + options.height) / 4,
        speed: options.speed,
        move,
        collidesWith
    };

    return physicalBody;
}

const GRAVITY = 0.25,
    ACCELERATION = 0.12;

function applyGravity(physicalBody, groudLevel) {
    if (physicalBody.coordinates.y === (groudLevel - physicalBody.height)) {
        return;
    } else if (physicalBody.coordinates.y > (groudLevel - physicalBody.height)) {
        physicalBody.coordinates.y = (groudLevel - physicalBody.height);
        physicalBody.speed.y = 0;
        return;
    }

    physicalBody.speed.y += GRAVITY;
}

function removeAcceleration(physicalBody) {
    if (physicalBody.speed.x > 0) {
        physicalBody.speed.x -= ACCELERATION;
    } else if (physicalBody.speed.x < 0) {
        physicalBody.speed.x += ACCELERATION;
    }
}