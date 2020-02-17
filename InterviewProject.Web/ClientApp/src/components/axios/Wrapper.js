import * as React from "react";
import axios from "axios";
import { AuthServiceInstance } from "../../service/AuthService";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { faCog } from "@fortawesome/free-solid-svg-icons";
import "./Spinner.scss";

const { useState, useCallback, useMemo, useEffect } = React;
export const axiosInstance = axios.create();

export const useAxiosLoader = () => {
  const [counter, setCounter] = useState(0);
  const [user, saveUser] = useState(null);
  const inc = useCallback(() => setCounter(counter => counter + 1), [
    setCounter
  ]); // add to counter
  const dec = useCallback(() => setCounter(counter => counter - 1), [
    setCounter
  ]); // remove from counter

  const interceptors = useMemo(
    () => ({
      request: config => {
        config.headers = {
          Authorization: `Bearer ${user.access_token}`,
          Accept: "application/json, text/plain, */*",
          "Content-Type": "application/json;charset=UTF-8"
        };
        inc();
        return config;
      },
      response: response => (dec(), response),
      error: error => {
        dec();
        if (error.response && error.response.status === 401) {
          console.log(error);
        }
        return Promise.reject(error);
      }
    }),
    [inc, dec, user]
  ); // create the interceptors

  useEffect(() => {
    if (!user) {
      AuthServiceInstance.registerLoginCallback(user => {
        if (user && user.access_token) {
          saveUser(user);
        }
      });
    }

    // add request interceptors
    const reqInterceptor = axiosInstance.interceptors.request.use(
      interceptors.request,
      interceptors.error
    );
    // add response interceptors
    const resInterceptor = axiosInstance.interceptors.response.use(
      interceptors.response,
      interceptors.error
    );
    return () => {
      // remove all intercepts when done
      axiosInstance.interceptors.request.eject(reqInterceptor);
      axiosInstance.interceptors.request.eject(resInterceptor);
    };
  }, [interceptors, user]);
  
  return counter > 0;
};

export function LoadingSpinner(props) {
  const isLoading = useAxiosLoader();
  return props.children(isLoading);
}

export class AxiosLoadingRenderProps extends React.Component {
  render() {
    return (
      <LoadingSpinner>
        {isLoading => (
          <div>
            {isLoading ? (
              <div id="spinner" className="loader center">
                <FontAwesomeIcon icon={faCog} className="fa-spin" />
              </div>
            ) : (
              ""
            )}
          </div>
        )}
      </LoadingSpinner>
    );
  }
}
