import ReactDOM from 'react-dom/client';
import { Provider } from 'react-redux';
import { BrowserRouter } from 'react-router-dom';
import Navigation from './Navigation';
import { setupStore } from './store';
import './Css/style.css'

const root = ReactDOM.createRoot(
  document.getElementById('root') as HTMLElement
);
root.render(
  <BrowserRouter>
    <Provider store={setupStore()}>
      <Navigation />
    </Provider>
  </BrowserRouter>
);
