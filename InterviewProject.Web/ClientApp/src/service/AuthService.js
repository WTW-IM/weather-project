import { Log, User, UserManager } from "oidc-client";

export class AuthService {
  userManager = new UserManager({});
  isLoggedIn = false;
  authTokenSet = false;
  user = {};
  callbacks = [];

  registerLoginCallback(callback) {
    if (this.isLoggedIn && this.authTokenSet) {
      callback(this.user);
    } else {
      this.callbacks.push(callback);
    }
  }

  createUserManager() {
    const rootUrl = "https://localhost:5001/";

    const settings = {
      authority: "https://demo.identityserver.io/",
      client_id: "implicit",
      redirect_uri: `${rootUrl}signin-callback.html`,
      silent_redirect_uri: `${rootUrl}silent-renew.html`,
      post_logout_redirect_uri: `${rootUrl}logged-out.html`,
      response_type: "id_token token",
      scope: "openid api"
    };
    this.userManager = new UserManager(settings);

    Log.logger = console;
    Log.level = Log.INFO;
  }

  authGuard = async () => {
    this.createUserManager();

    let user = await this.userManager.getUser();
    if (!user || !user.access_token) {
      this.user = null;
      this.isLoggedIn = false;
      this.login();
    } else {
      this.user = user;
      this.isLoggedIn = true;
      this.onAuthTokenSet(user);
    }
  };

  onAuthTokenSet = user => {
    this.authTokenSet = true;

    for (let i = 0; i < this.callbacks.length; i++) {
      this.callbacks[i](user);
    }
  };

  login = () => {
    return this.userManager.signinRedirect();
  };
}

export const AuthServiceInstance = new AuthService();
