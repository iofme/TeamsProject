export interface Message {
  id: number
  senderId: number
  sendUser: string
  recipientId: number
  recipientUser: string
  content: string
  dateRead: any
  messageSent: string
}
