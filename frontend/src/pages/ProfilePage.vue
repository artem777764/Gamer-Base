<script setup lang="ts">
import Card from '@/components/Card.vue';
import { useUserStore } from '@/stores/user';
import type { IUser } from '@/types/user';
import axios from 'axios';
import { onMounted, ref } from 'vue';
import { useRoute, useRouter } from 'vue-router';

const route = useRoute()
const profileId = route.params.id as string

const router = useRouter()

const userStore = useUserStore()

const user = ref<IUser>();
const fileInputRef = ref<HTMLInputElement | null>(null);

async function getUser() {
  try {
    const response = await axios.get(`http://localhost:5007/Authorization/GetUserInfo/${profileId}`,  {
      withCredentials: true,
      params: {
        userId: profileId,
      }
    })
    user.value = response.data
  } catch (error) {
    console.log('Не удалось загрузить пользователя')
  }
}

function triggerFileInput() {
  fileInputRef.value?.click();
}

async function handleFileSelected(event: Event) {
  const target = event.target as HTMLInputElement;
  const file = target.files?.[0];
  if (!file) return;

  const formData = new FormData();
  formData.append('File', file);

  try {
    await axios.put('http://localhost:5007/Authorization/UpdateProfilePhoto', formData, {
      withCredentials: true,
      headers: {
        'Content-Type': 'multipart/form-data',
      },
    });

    await getUser();
  } catch (error) {
    console.error('Ошибка при загрузке фото', error);
  }
}

function exit() {
  userStore.logout()
  router.push('/')
}

onMounted(() => {
  getUser()
})
</script>

<template>
  <div class="fixed inset-0 -z-10">
    <div 
      class="absolute inset-0 bg-[url('/images/ProfilePageBackground.jpg')] bg-no-repeat bg-cover bg-center"
    ></div>
  </div>
  
  <div class="relative min-h-screen overflow-hidden">
    <div class="flex justify-center mt-[100px]">
      <div class="bg-background p-1 rounded">
        <div class="relative">
          <Card :image-src="user?.UserImageURL ?? ''" aspect="aspect-[1/1]" width="w-[300px]" class="shadow-md"/>
          <div class="absolute bottom-1 right-1">
            <Card
              @click="triggerFileInput"
              image-src="/images/icons/pensil.png"
              aspect="aspect-[1/1]"
              width="w-[40px]"
              class="bg-primary p-1 transition duration-150 filter hover:brightness-110 active:brightness-125 cursor-pointer"
            />
            <input
              ref="fileInputRef"
              type="file"
              accept="image/*"
              class="hidden"
              @change="handleFileSelected"
            />
          </div>
          <div class="absolute bottom-1 left-1">
            <Card
              @click="exit"
              image-src="/images/icons/exit.png"
              aspect="aspect-[1/1]"
              width="w-[40px]"
              class="bg-primary p-1 transition duration-150 filter hover:brightness-110 active:brightness-125 cursor-pointer"
            />
          </div>
        </div>
      </div>
    </div>
  </div>
</template>