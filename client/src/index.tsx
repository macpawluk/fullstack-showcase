import * as React from "react";
import * as ReactDOM from "react-dom";
import { Provider } from "react-redux";
import { applyMiddleware, createStore } from "redux";
import { composeWithDevTools } from "redux-devtools-extension";
import reduxPromise from "redux-promise-middleware";
import thunk from "redux-thunk";

import { App } from "./app";
import { rootReducer } from "./RootReducer";
import { register as registerServiceWorker } from "./ServiceWorker";

const store = createStore(
  rootReducer,
  composeWithDevTools(applyMiddleware(reduxPromise(), thunk))
);

ReactDOM.render(
  <Provider store={store}>
    <App />
  </Provider>,
  document.getElementById("root") as HTMLElement
);
registerServiceWorker();
