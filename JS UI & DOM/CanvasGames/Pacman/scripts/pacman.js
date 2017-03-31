function getPacman(options) {
    const { canvas, context, coordinates, direction, size, speed, loopTicksPerFrame } = options;
    context.fillStyle = 'yellow';

    function render() {
        const self = this,
            x = self.coordinates.x + self.size / 2,
            y = self.coordinates.y + self.size / 2,
            size = self.size / 2;

        self.context.clearRect(
            0,
            0,
            self.canvas.width,
            self.canvas.height
        );
        self.context.beginPath();

        if (self.isMouthOpen) {
            self.context.arc(
                x,
                y,
                size,
                self.direction.mouth * Math.PI / 2 + Math.PI / 4,
                self.direction.mouth * Math.PI / 2 + 7 * Math.PI / 4
            );
            self.context.lineTo(x, y);
        } else {
            self.context.arc(
                x,
                y,
                size,
                0,
                2 * Math.PI);
        }
        self.context.fill();

        return self;
    }

    function update() {
        const self = this;

        self.loopTicksCount += 1;
        if (self.loopTicksCount >= self.loopTicksPerFrame) {
            self.loopTicksCount = 0;
            self.isMouthOpen = !self.isMouthOpen;
        }

        if (!self.isCollided) {
            self.coordinates.x += self.direction.x * self.speed;
            self.coordinates.y += self.direction.y * self.speed;
        }

        self.coordinates.x = (self.coordinates.x + self.canvas.width) % self.canvas.width;
        self.coordinates.y = (self.coordinates.y + self.canvas.height) % self.canvas.height;

        return self;
    }

    const pacman = {
        canvas,
        context,
        coordinates,
        size,
        speed,
        direction,
        isMouthOpen: true,
        isCollided: false,
        loopTicksCount: 0,
        loopTicksPerFrame,
        render,
        update,
    };

    return pacman;
}

function getFood(options) {
    const { coordinates, size } = options;

    function render(context) {
        context.fillStyle = 'yellow';

        const self = this,
            x = self.coordinates.x + self.size / 2,
            y = self.coordinates.y + self.size / 2,
            size = self.size / 2;

        context.beginPath();
        context.arc(
            x,
            y,
            size,
            0,
            2 * Math.PI);
        context.fill();

        return self;
    }

    const food = {
        coordinates,
        size,
        render
    };

    return food;
}

function getMaze(options) {
    const { context, size, wall } = options,
    maze = [
            '**********  ** *****',
            '********** ***     *',
            '       *** *** ***  ',
            ' ***** ***   * **** ',
            '****** *****   *****',
            '******     *** *****',
            '**********  ** *****',
        ],
        foodChar = ' ',
        wallChar = '*';

    function render() {
        const self = this;

        for (let row = 0, length = self.rows; row < length; row += 1) {
            for (let col = 0, length = self.cols; col < length; col += 1) {
                if (self.maze[row][col] === foodChar) {
                    self.foodArray.push(
                        getFood({
                            coordinates: {
                                x: col * self.size + self.size / 4,
                                y: row * self.size + self.size / 4
                            },
                            size: self.size / 2
                        }));
                } else if (self.maze[row][col] === wallChar) {
                    self.context.drawImage(
                        wall,
                        0,
                        0,
                        self.size,
                        self.size,
                        col * self.size,
                        row * self.size,
                        self.size,
                        self.size
                    );

                    self.wallArray.push({
                        coordinates: { x: col * self.size, y: row * self.size },
                        size: self.size
                    });
                } else {
                    throw new Error('maze error');
                }
            }
        }
        return self;
    }

    const labyrinth = {
        context,
        maze,
        size,
        wall,
        rows: maze.length,
        cols: maze[0].length,
        foodArray: [],
        wallArray: [],
        foodChar,
        wallChar,
        render,
    };

    return labyrinth;
}


function collided(object1, object2, pacmanParameter) {
    let x1 = object1.coordinates.x,
        x2 = object1.coordinates.x + object1.size,
        y1 = object1.coordinates.y,
        y2 = object1.coordinates.y + object1.size,

        x1Object = object2.coordinates.x,
        x2Object = object2.coordinates.x + object2.size,
        y1Object = object2.coordinates.y,
        y2Object = object2.coordinates.y + object2.size;

    if (pacmanParameter === 1) {
        x1 += object1.direction.x * object1.speed;
        x2 += object1.direction.x * object1.speed;
        y1 += object1.direction.y * object1.speed;
        y2 += object1.direction.y * object1.speed;
    } else if (pacmanParameter === 2) {
        x1Object += object2.direction.x * object2.speed;
        x2Object += object2.direction.x * object2.speed;
        y1Object += object2.direction.y * object2.speed;
        y2Object += object2.direction.y * object2.speed;
    }

    if (((x1 <= x1Object && x1Object <= x2) ||
            (x1 <= x2Object && x2Object <= x2)) &&
        ((y1 <= y1Object && y1Object <= y2) ||
            (y1 <= y2Object && y2Object <= y2))) {
        return true;
    }

    return false;
}