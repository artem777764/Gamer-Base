<script setup lang="ts">
import MyForm from '@/components/MyForm.vue';
import axios from 'axios';
import { ref } from 'vue';
import { useRouter } from 'vue-router';

const router = useRouter()

const userName = ref('');
const password = ref('');
const message = ref('')
const messageColor = ref('text-red-500')

const handleSubmit = async () => {
    try {
        await axios.post('http://localhost:5007/Authorization/Login', {
            UserName: userName.value,
            Password: password.value,
        }, { withCredentials: true })
        
        // localStorage.setItem('jwtToken', response.data.JwtToken)

        message.value = 'Успешный вход!'
        messageColor.value = 'text-green-500'

        setTimeout(() => {
            router.push('/search-result')
        }, 1500)
    } catch (error: any) {
        message.value = error.response?.data?.Message || 'Что-то пошло не так'
    }
}

</script>

<template>
    <div class="min-h-screen bg-background flex justify-center items-center">
        <form @submit.prevent="handleSubmit">
            <MyForm>
                <p class=" font-russo leading-none text-shadow text-white text-3xl text-center">Gamer Base</p>
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
                <MyInput v-model="userName" placeholder="Email/Login"></MyInput>
                <MyInput v-model="password" placeholder="Password" is-password></MyInput>
                <div class="flex flex-col gap-0 items-center">
                    <MyButton class="w-full" type="submit">
                        Войти
                    </MyButton>
                    <router-link to="/register">
                        <p class="font-russo leading-none text-shadow text-gray-300 text-xs underline mt-1">Не зарегистрированны?</p>
                    </router-link>
                </div>
            </MyForm>
        </form>
    </div>
</template>