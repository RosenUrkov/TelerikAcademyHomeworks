class Food {
    constructor(canvas, context, objectSize) {
        this.canvas = canvas;

        this.context = context;
        this.context.lineWidth = 5;

        this.width = objectSize.width;
        this.height = objectSize.height;

        this.coordinates = this._getCoordinates;
        this.isEaten = true;
    }

    get _fillStyle() {
        return 'grey';
    }

    get _strokeStyle() {
        return 'black';
    }

    get _getCoordinates() {
        const coordinates = {
            x: (Math.random() * (this.canvas.width - this.width)) | 0,
            y: (Math.random() * (this.canvas.height - this.height)) | 0
        };

        return coordinates;
    }

    render() {
        this.context.clearRect(
            this.coordinates.x - 3,
            this.coordinates.y - 3,
            this.width + 6,
            this.height + 6
        );

        this.context.fillStyle = this._fillStyle;
        this.context.strokeStyle = this._strokeStyle;

        if (this.isEaten) {
            this.coordinates = this._getCoordinates;
        }
        this.isEaten = false;

        this.context.fillRect(
            this.coordinates.x,
            this.coordinates.y,
            this.width,
            this.height
        );

        this.context.strokeRect(
            this.coordinates.x,
            this.coordinates.y,
            this.width,
            this.height
        );
    }
}