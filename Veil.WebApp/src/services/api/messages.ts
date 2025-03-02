import axios from 'axios'
import type { Message } from 'src/components/models'

const BASE_URL = '/api'

export async function getMessages(): Promise<Message[]> {
  const messages: Message[] = (await axios.get(`${BASE_URL}/message/all`)).data
  return messages.map((message) => ({
    ...message,
    from: message.author || 'N/A',
  }))
}

export function test() {}
