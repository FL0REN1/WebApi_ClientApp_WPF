import { createSlice, PayloadAction } from "@reduxjs/toolkit";
import { IChatRead } from "../../../models/chat/IChatRead";
import { changeMessage, clearChat, createMessage, getAllMessages, getMessageById } from "./chatActionCreator";

interface IChatState {
    Chats: IChatRead[];
    isLoading: boolean;
    error: string | null;
}

const initialState : IChatState = {
    Chats: [],
    isLoading: false,
    error: null
}

export const ChatSlice = createSlice({
    name: 'chat',
    initialState,
    reducers: {},
    extraReducers: {
        //#region [Get_All_Messages]

        [getAllMessages.pending.type]: (state) => {
            state.Chats = [];
            state.isLoading = true;
            state.error = null;
        },
        [getAllMessages.fulfilled.type]: (state, action: PayloadAction<IChatRead[]>) => {
            state.Chats = action.payload;
            state.isLoading = false;
            state.error = null;
        },
        [getAllMessages.rejected.type]: (state, action: PayloadAction<string>) => {
            state.Chats = [];
            state.isLoading = false;
            state.error = action.payload;
        },

        //#endregion

        //#region [Get_Message_By_Id]

        [getMessageById.pending.type]: (state) => {
            state.Chats = [];
            state.isLoading = true;
            state.error = null;
        },
        [getMessageById.fulfilled.type]: (state, action: PayloadAction<IChatRead[]>) => {
            state.Chats = action.payload;
            state.isLoading = false;
            state.error = null;
        },
        [getMessageById.rejected.type]: (state, action: PayloadAction<string>) => {
            state.Chats = [];
            state.isLoading = false;
            state.error = action.payload;
        },

        //#endregion

        //#region [Create_Message]

        [createMessage.pending.type]: (state) => {
            state.Chats = [];
            state.isLoading = true;
            state.error = null;
        },
        [createMessage.fulfilled.type]: (state, action: PayloadAction<IChatRead>) => {
            state.Chats.push(action.payload);
            state.isLoading = false;
            state.error = null;
        },
        [createMessage.rejected.type]: (state, action: PayloadAction<string>) => {
            state.Chats = [];
            state.isLoading = true;
            state.error = action.payload;
        },

        //#endregion

        //#region [Delete_Message]

        [createMessage.pending.type]: (state) => {
            state.isLoading = true;
            state.error = null;
        },
        [createMessage.fulfilled.type]: (state, action: PayloadAction<IChatRead>) => {
            state.Chats.filter(user => user.id !== action.payload.id);
            state.isLoading = false;
            state.error = null;
        },
        [createMessage.rejected.type]: (state, action: PayloadAction<string>) => {
            state.isLoading = false;
            state.error = action.payload;
        },

        //#endregion

        //#region [Change_Message]

        [changeMessage.pending.type]: (state) => {
            state.isLoading = true;
            state.error = null;
        },
        [changeMessage.fulfilled.type]: (state) => {
            state.isLoading = false;
            state.error = null;
        },
        [changeMessage.rejected.type]: (state, action: PayloadAction<string>) => {
            state.isLoading = true;
            state.error = action.payload;
        },

        //#endregion

        //#region [Clear_Chat]

        [clearChat.pending.type]: (state) => {
            state.isLoading = true;
            state.error = null;
        },
        [clearChat.fulfilled.type]: (state) => {
            state.isLoading = false;
            state.error = null;
        },
        [clearChat.rejected.type]: (state, action: PayloadAction<string>) => {
            state.isLoading = true;
            state.error = action.payload;
        },

        //#endregion
    }
})

export default ChatSlice.reducer;