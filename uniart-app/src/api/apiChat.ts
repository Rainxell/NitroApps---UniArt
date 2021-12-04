import React, { useState } from 'react';
import { Chat } from "../models/_chat";
import request from './api';

const apiChat = {
	list: () => request.get<Chat[]>("/Chat"),
	add: (data: Chat) => request.post("/Chat", data),
	edit: (data: Chat) => request.put(`/Chat/${data.id}`, data),
	delete: (id: number) => request.delete(`/Chat/${id}`),
	detail: (id: number) => request.get<Chat>(`/Chat/${id}`),
};

export default apiChat;

//READ LIST 
export const ListChats = (from?: number, to?: number) => {
	if (from === undefined) from = 0;
	const [chats, setChats] = React.useState<Chat[]>([]);
	function refreshChats() {
		apiChat.list().then((res) => {
			to === undefined ? setChats(res.slice(from, res.length))
				: setChats(res.slice(from, to));
			console.log('l chats:', res);
		});
	}
	return { chats, refreshChats };
};

//READ ONE (DETAILS)
export const GetChat = (id: number) => {
	const [chat, setChat] = React.useState<Chat>(new Chat);
	function refreshChat() {
		apiChat.detail(id).then((res) => {
			setChat(res);
			console.log('i chat:', res);
		}).catch(() => { "no listó chat" });
	}
	return { chat, refreshChat };
};

//CREATE
export const CreateChat = (chat: Chat) => {
	apiChat.add(chat).then(() => {
	}).catch(() => { console.log("no creó chat") });
};

//UPDATE
export const UpdateChat = (chat: Chat) => {
	apiChat.edit(chat).then(() => {
	}).catch(() => { console.log("no actualizó chat"); });
};

//DELETE
export const DeleteChat = (id: number) => {
	apiChat.delete(id).then(() => {
	}).catch(() => { "no eliminó chat" });
};