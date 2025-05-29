<script setup lang="ts">
import { ref } from 'vue';
import MyInput from '@/components/ui/MyInput.vue';
import MyButton from '@/components/ui/MyButton.vue';
import axios from 'axios';

const props = defineProps<{
    gameId: number,
}>()

const isOpen = ref(false)
const mark = ref()
const title = ref()
const content = ref()
const message = ref()
const messageColor = ref('text-red-500')

async function SendReview () {
    try {
        await axios.post('http://localhost:5007/Review', {
            GameId: props.gameId,
            Mark: mark.value,
            Title: title.value,
            Content: content.value,
        }, {
            withCredentials: true
        })

        message.value = 'Отзыв отправлен!'
        messageColor.value = 'text-green-500'

        setTimeout(() => {
            isOpen.value = !isOpen.value
        }, 1500)
    } catch (error) {
        message.value = 'Что-то пошло не так'
    }
}

function handleWriter() {
    isOpen.value = !isOpen.value
}

async function handleSubmit() {
    const parsedMark = parseFloat(mark.value)
    if (!(Number.isFinite(parsedMark) && parsedMark >= 1.00 && parsedMark <= 5.00)) {
        message.value = 'Оценка - число от 1.00 до 5.00'
        return
    }
    if (title.value.length > 80) {
        message.value = 'Заголовок не больше 80 символов'
        return
    }
    if (content.value.length > 4000) {
        message.value = 'Содержание не больше 4000 символов'
        return
    }
    await SendReview()
}

</script>

<template>
    <div class="flex flex-col gap-3 p-5 bg-secondary rounded shadow-md ">
        <p @click="handleWriter" class="font-russo leading-none text-shadow text-white text-3xl">Написать обзор</p>
        <div v-if="isOpen" class="flex flex-col gap-3">
            <Transition
                enter-active-class="transition-all duration-500 ease-in-out"
                enter-from-class="opacity-0 max-h-0"
                enter-to-class="opacity-100 max-h-40"
                leave-active-class="transition-all duration-500 ease-in-out"
                leave-from-class="opacity-100 max-h-40"
                leave-to-class="opacity-0 max-h-0"
                >
                <p
                    v-if="message"
                    :class="['overflow-hidden font-russo leading-none text-xl text-center', messageColor]"
                >
                    {{ message }}
                </p>
            </Transition>
            <MyInput v-model="mark" placeholder="Оценка (От 1.00 до 5.00)" class="w-full"/>
            <MyInput v-model="title" placeholder="Заголовок" class="w-full"/>
            <MyInput v-model="content" placeholder="Ваш подробный рассказ по всех красках" multiline/>
            <div class="flex justify-end">
                <MyButton  @click="handleSubmit" class="">Написать</MyButton>
            </div>
        </div>
    </div>
</template>