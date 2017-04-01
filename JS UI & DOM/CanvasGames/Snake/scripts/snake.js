class Snake {
    constructor(canvas, context, objectSize, initialSnakeLength, framesCount) {
        this.canvas = canvas;

        this.context = context;
        this.context.lineWidth = 5;

        this.partWidth = objectSize.width;
        this.partHeight = objectSize.height;

        this.lastCoordinates = { x: 0, y: 0 };
        this.lastDirection = { x: 1, y: 0 };
        this.isReverseDirection = false;

        this.score = 0;
        this.isAlive = true;

        this.frame = 0;
        this.framesCount = framesCount;

        this.body =
            Array.from({ length: initialSnakeLength })
            .fill({})
            .map((part, index) => {
                return { coordinates: { x: index * this.partWidth, y: 0 } }
            });
        this.head = this.body[0];
    }

    get _fillStyle() {
        return 'yellow';
    }

    get _strokeStyle() {
        const gradient = this.context.createLinearGradient(
            this.head.coordinates.x,
            this.head.coordinates.y,
            this.head.coordinates.x + this.partWidth,
            this.head.coordinates.y + this.partHeight
        );

        gradient.addColorStop("0", "magenta");
        gradient.addColorStop("0.5", "blue");
        gradient.addColorStop("1.0", "red");

        return gradient;
    }

    render() {
        this.context.clearRect(
            this.lastCoordinates.x - 3,
            this.lastCoordinates.y - 3,
            this.partWidth + 6,
            this.partHeight + 6
        );

        this.context.fillStyle = this._fillStyle;
        this.context.strokeStyle = this._strokeStyle;

        this.body.forEach(part => {
            this.context.fillRect(
                part.coordinates.x,
                part.coordinates.y,
                this.partWidth,
                this.partHeight
            );

            this.context.strokeRect(
                part.coordinates.x,
                part.coordinates.y,
                this.partWidth,
                this.partHeight
            );
        });

        return this;
    }

    update(moveDirection) {
        if (this.frame < this.framesCount) {
            this.frame += 1;
            return this;
        }
        this.frame = 0;

        if ((this.lastDirection.x === 0 && this.lastDirection.y === -moveDirection.y) ||
            (this.lastDirection.y === 0 && this.lastDirection.x === -moveDirection.x)) {
            this.body.reverse();
        }
        this.lastDirection = moveDirection;

        this.head = this.body.shift();
        this.lastCoordinates.x = this.head.coordinates.x;
        this.lastCoordinates.y = this.head.coordinates.y;

        this.head.coordinates.x = ((this.body[this.body.length - 1].coordinates.x + this.partWidth * moveDirection.x) + this.canvas.width) % this.canvas.width;
        this.head.coordinates.y = ((this.body[this.body.length - 1].coordinates.y + this.partHeight * moveDirection.y) + this.canvas.height) % this.canvas.height;

        this.body.forEach(part => {
            if (this.head.coordinates.x === part.coordinates.x && this.head.coordinates.y === part.coordinates.y) {
                this.isAlive = false;
            }
        });

        this.body.push(this.head);

        return this;
    }

    tryEatFood(food) {
        if (((this.head.coordinates.x <= food.coordinates.x && food.coordinates.x <= this.head.coordinates.x + this.partWidth) ||
                (this.head.coordinates.x <= food.coordinates.x + food.width && food.coordinates.x + food.width <= this.head.coordinates.x + this.partWidth)) &&
            ((this.head.coordinates.y <= food.coordinates.y && food.coordinates.y <= this.head.coordinates.y + this.partHeight) ||
                (this.head.coordinates.y <= food.coordinates.y + food.height && food.coordinates.y + food.height <= this.head.coordinates.y + this.partHeight))) {

            food.isEaten = true;
            this.score += 1;
            this.body.unshift({ coordinates: { x: this.canvas.width + 50, y: this.canvas.height + 50 } });
        }

        return this;
    }
}