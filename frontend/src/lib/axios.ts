import axios from "axios";
import { type Router } from 'vue-router';

const api = axios.create({
  baseURL: 'http://localhost:5007',
  withCredentials: true,
})

export function setupApiInterceptor(router: Router) {
  api.interceptors.response.use(
    (response) => response,
    (error) => {
      if (error.response?.status === 401) {
        router.push('/login');
      }
      return Promise.reject(error);
    }
  );
}

export default api