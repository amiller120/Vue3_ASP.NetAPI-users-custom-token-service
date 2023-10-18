import ApiServiceBase from "./ApiServiceBase"


class TestService extends ApiServiceBase {

    constructor(resource_name: string) {
        super(resource_name);
    }

    async GetTest<T>() {
        return await this.Get<T>("", null);
    }
}

export default new TestService("test");
