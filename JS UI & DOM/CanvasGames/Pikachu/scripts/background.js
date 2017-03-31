function createBackground() {
    const backgroudContext = document.getElementsByTagName('canvas')[2].getContext('2d'),
        backgroundImg = document.getElementById('background');

    function render() {
        backgroudContext.drawImage(
            this.image,
            this.coordinates.x,
            0
        );

        backgroudContext.drawImage(
            this.image,
            this.image.width - Math.abs(this.coordinates.x),
            0
        )
    }

    function update(offset) {
        this.coordinates.x -= 5;

        if (Math.abs(this.coordinates.x) > this.image.width) {
            this.coordinates.x = 0;
        }
    }

    const background = {
        coordinates: { x: 0, y: 0 },
        image: backgroundImg,
        render,
        update
    }

    return background;
}