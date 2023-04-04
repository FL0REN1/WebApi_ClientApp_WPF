import { createSlice, PayloadAction } from "@reduxjs/toolkit";
import { IUserRead } from "../../../models/user/IUserRead";
import { changeUserStatus, checkLoginUser, createUser, deleteUser, getAllUsers, getUser } from "./userActionCreator";

interface IUserState {
    Users: IUserRead[];
    IsLoading: boolean;
    Error: string | null;
}

const initialState: IUserState = {
    Users: [],
    IsLoading: false,
    Error: null
}

export const UserSlice = createSlice({
    name: "user",
    initialState,
    reducers: {},
    extraReducers: {
        //#region [Get_All_Users]

        [getAllUsers.pending.type]: (state) => {
            state.Users = [];
            state.IsLoading = true;
            state.Error = null;
        },
        [getAllUsers.fulfilled.type]: (state, action: PayloadAction<IUserRead[]>) => {
            state.Users = action.payload;
            state.IsLoading = false;
            state.Error = null;
        },
        [getAllUsers.rejected.type]: (state, action: PayloadAction<string>) => {
            state.Users = [];
            state.IsLoading = false;
            state.Error = action.payload;
        },

        //#endregion

        //#region [Get_User_By_Id]

        [getUser.pending.type]: (state) => {
            state.Users = [];
            state.IsLoading = true;
            state.Error = null;
        },
        [getUser.fulfilled.type]: (state, action: PayloadAction<IUserRead[]>) => {
            state.Users = action.payload;
            state.IsLoading = false;
            state.Error = null;
        },
        [getUser.rejected.type]: (state, action: PayloadAction<string>) => {
            state.Users = [];
            state.IsLoading = false;
            state.Error = action.payload;
        },

        //#endregion

        //#region [Create_User]

        [createUser.pending.type]: (state) => {
            state.IsLoading = true;
            state.Error = null;
        },
        [createUser.fulfilled.type]: (state, action: PayloadAction<IUserRead>) => {
            state.Users.push(action.payload);
            state.IsLoading = false;
            state.Error = null;
        },
        [createUser.rejected.type]: (state, action: PayloadAction<string>) => {
            state.IsLoading = false;
            state.Error = action.payload;
        },

        //#endregion

        //#region [Delete_User]

        [deleteUser.pending.type]: (state) => {
            state.IsLoading = true;
            state.Error = null;
        },
        [deleteUser.fulfilled.type]: (state, action: PayloadAction<IUserRead>) => {
            state.Users.filter(user => user.id !== action.payload.id);
            state.IsLoading = false;
            state.Error = null;
        },
        [deleteUser.rejected.type]: (state, action: PayloadAction<string>) => {
            state.IsLoading = false;
            state.Error = action.payload;
        },

        //#endregion

        //#region [Check_Login_User]

        [checkLoginUser.pending.type]: (state) => {
            state.IsLoading = true;
            state.Error = null;
        },
        [checkLoginUser.fulfilled.type]: (state, action: PayloadAction<IUserRead[]>) => {
            state.Users = action.payload;
            state.IsLoading = false;
            state.Error = null;
        },
        [checkLoginUser.rejected.type]: (state, action: PayloadAction<string>) => {
            state.IsLoading = false;
            state.Error = action.payload;
        },

        //#endregion

        //#region [Change_User_Status]

        [changeUserStatus.pending.type]: (state) => {
            state.IsLoading = true;
            state.Error = null;
        },
        [changeUserStatus.fulfilled.type]: (state) => {
            state.IsLoading = false;
            state.Error = null;
        },
        [changeUserStatus.rejected.type]: (state, action: PayloadAction<string>) => {
            state.IsLoading = false;
            state.Error = action.payload;
        },

        //#endregion
    }
})

export default UserSlice.reducer;