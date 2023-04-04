import { configureStore } from "@reduxjs/toolkit";
import { combineReducers } from "redux";
import ChatSlice from "./reducers/chat/chatSlice";
import UserSlice from "./reducers/user/userSlice";

const rootReducer = combineReducers({
    UserSlice,
    ChatSlice
});

export const setupStore = () => {
    return configureStore({
        reducer: rootReducer,
    });
}

export type typeStore = ReturnType<typeof setupStore>;
export type typeRoot = ReturnType<typeof rootReducer>;
export type typeDispatch = typeStore["dispatch"];