<script setup lang="ts">
import MyForm from '@/components/MyForm.vue';
import { ref } from 'vue';
import { useRouter } from 'vue-router'
import api from '@/lib/axios';

const router = useRouter()

const email = ref('')
const login = ref('')
const password = ref('')
const passwordConfirm = ref('')
const message = ref('')
const messageColor = ref('text-red-500')

const emailRegex = /^(?![.])(?:[a-zA-Z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-zA-Z0-9!#$%&'*+/=?^_`{|}~-]+)*)@(?:[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?\.)+[a-zA-Z]{2,}$/
const loginRegex = /^[a-zA-Z0-9_]{3,20}$/
const passwordRegex = /^[^\s]{6,}$/


const handeSubmit = async () => {

    if(!emailRegex.test(email.value)) {
        message.value = 'Некорректная почта'
        return;
    }
    if(!loginRegex.test(login.value)) {
        message.value = 'Некорректный логин'
        return;
    }
    if(!passwordRegex.test(password.value)) {
        message.value = 'Некорректный пароль'
        return;
    }
    if(password.value != passwordConfirm.value) {
        message.value = 'Пароли не совпадают'
        return;
    }

    try {
        await api.post('/Authorization/Register', {
            Email: email.value,
            Login: login.value,
            Password: password.value,
            PasswordConfirm: passwordConfirm.value
        })

        message.value = 'Успешная регистрация!'
        messageColor.value = 'text-green-500'

        setTimeout(() => {
            router.push('/login')
        }, 1500)

    } catch (error: any) {
        message.value = error.response?.data?.Message || 'Что-то пошло не так'
    }
}
</script>

<template>
    <div class="min-h-screen bg-background flex justify-center items-center">
        <form @submit.prevent="handeSubmit">
            <MyForm>
                <p class="font-russo leading-none text-shadow text-white text-3xl text-center">Gamer Base</p>
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
                        :class="['overflow-hidden font-russo leading-none text-xs text-center', messageColor]"
                    >
                        {{ message }}
                    </p>
                </Transition>
                <MyInput v-model="email" placeholder="Почта"></MyInput>
                <MyInput v-model="login" placeholder="Логин"></MyInput>
                <MyInput v-model="password" placeholder="Пароль" is-password></MyInput>
                <MyInput v-model="passwordConfirm" placeholder="Повторить пароль" is-password></MyInput>
                <div class="flex flex-col gap-0 items-center">
                    <MyButton class="w-full" type="submit">
                        Зарегистрироваться
                    </MyButton>
                    <router-link to="/login">
                        <p class="font-russo leading-none text-shadow text-gray-300 text-xs underline mt-1">Уже есть аккаунт?</p>
                    </router-link>
                </div>
            </MyForm>
        </form>
    </div>
</template>