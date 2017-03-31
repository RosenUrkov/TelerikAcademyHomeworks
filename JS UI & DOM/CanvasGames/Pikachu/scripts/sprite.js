function createSprite(options) {

    function render(drawCoordinates, clearCoordinates) {
        const self = this;

        self.context.clearRect(
            clearCoordinates.x,
            clearCoordinates.y,
            self.width,
            self.height
        );

        self.context.drawImage(
            self.spritesheet,
            self.frameIndex * self.width,
            0,
            self.width,
            self.height,
            drawCoordinates.x,
            drawCoordinates.y,
            self.width,
            self.height
        );

        return self;
    }

    function update() {
        const self = this;

        self.loopTicksCount += 1;
        if (self.loopTicksCount >= self.loopTicksPerFrame) {
            self.loopTicksCount = 0;

            self.frameIndex += 1;
            if (self.frameIndex >= self.numberOfFrames) {
                self.frameIndex = 0;
            }
        }

        return self;
    }

    const sprite = {
        spritesheet: options.spritesheet,
        context: options.context,
        width: options.width,
        height: options.height,
        frameIndex: 0,
        numberOfFrames: options.numberOfFrames,
        loopTicksCount: 0,
        loopTicksPerFrame: options.loopTicksPerFrame,
        render,
        update
    };

    return sprite;
}