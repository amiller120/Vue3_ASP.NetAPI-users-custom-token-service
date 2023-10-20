import ApiServiceBase from "./ApiServiceBase"
import { registerResponse } from "./Models/registerResponse";


class AuthService extends ApiServiceBase {

  constructor(resource_name: string) {
    super(resource_name);
  }

  async Login<TokenResponse>(email: string, password: string) {
    let loginRequest = {
      email: email,
      password: password
    }
    return await this.Post<TokenResponse>("/login", loginRequest);
  }

  async register<registerResponse>(email: string, name: string, password: string) {
    let registerRequest = {
      email: email,
      password: password,
      name: name
    }

    return await this.Post<registerResponse>("/register", registerRequest);
  }
}

export default new AuthService("auth");
